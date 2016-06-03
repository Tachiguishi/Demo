### SqlMapper类
iBatis中，加载/分析配置文件和映射文件是在创建SqlMapper实例时进行的。对数据库的操作是通过SqlMapper实例进行  
创建方式(需要添加`using IBatisNet.DataMapper;`)：
```c#
ISqlMapper mapper = Mapper.Instance();
```
在第一次调用Mapper.Instance()的时候，由DomSqlMapBuilder对象解析SqlMap.config(默认路径和命名)文件来创建SqlMapper实例，然后会缓存该mapper对象，如果程序运行过程中，修改了映射文件，那么再调用Mapper.Instance()创建SqlMapper实例时，SqlMapper会被重新加载创建。相当于一个文件缓存依赖，这个文件缓存依赖由DomSqlMapBuilder.ConfigureAndWatch方法来实现
如果你不希望修改了配置文件就重新加载，可以通过
```c#
DomSqlMapBuilder builder = new DomSqlMapBuilder();
ISqlMapper mapper = builder.Configure("SqlMap.config文件路径");
```
iBatis.Net默认使用HttpContext作为容器，在非Web请求线程调用是会报错：
> ibatis.net：WebSessionStore: Could not obtain reference to HttpContext

解决：
```c#
SqlMapper.SessionStore = new HybridWebThreadSessionStore(sqlMapper.Id);
 
/// <summary>
/// 初始化
/// </summary>
/// <param name="sqlMapperPath"></param>
public void InitMapper(string sqlMapperPath)
{
　　ConfigureHandler handler = new ConfigureHandler(Configure);
　　DomSqlMapBuilder builder = new DomSqlMapBuilder();
　　_mapper = builder.ConfigureAndWatch(sqlMapperPath, handler);
　　_mapper.SessionStore = new IBatisNet.DataMapper.SessionStore.HybridWebThreadSessionStore(_mapper.Id);
}
```
[详细解释](http://www.iloveher.cn/ibatis/hybridwebthreadsessionstore.html)

### 数据库操作
#### Select
1. **QueryForList**  
  返回List<T>强类型数据集合  
  方法原型：  
  ```c#
  public IList<T> QueryForList<T>(string statementName, object parameterObject);
  public IList QueryForList(string statementName, object parameterObject);
  public void QueryForList<T>(string statementName, object parameterObject, IList<T> resultObject);
  public void QueryForList(string statementName, object parameterObject, IList resultObject);
  public IList<T> QueryForList<T>(string statementName, object parameterObject, int skipResults,int maxResults);
  public IList QueryForList(string statementName, object parameterObject, int skipResult
  ``` 
  可以看出，其实只是3个参数不同方法，只是分为泛型与非泛型两个版本而已。  
  参数skipResults，表示从结果行掉过skipResults行后返回，maxResults表示返回的行数。这个在分页中应该会用到。
2. **QueryForObject**  
  返回一行数据对应的实体类实例  
  方法原型:  
  ```c#
  public object QueryForObject(string statementName, object parameterObject);
  public T QueryForObject<T>(string statementName, object parameterObject);
  public T QueryForObject<T>(string statementName, object parameterObject, T instanceObject);
  public object QueryForObject(string statementName, object parameterObject, object resultObject)
  ```
3. **QueryWithRowDelegate**  
  通过委托过滤返回数据  
  方法原型：  
  ```c#
  IList<T> QueryWithRowDelegate<T>(string statementName, object parameterObject, RowDelegate<T> rowDelegate);
    IList QueryWithRowDelegate(string statementName, object parameterObject, RowDelegate rowDelegate);
  ```
4. **QueryForDictionary**  
5. **QueryForMap**  

#### Insert
`public object Insert(String statementName, Object parameterObject)`  
返回值为新插入行的主键(可能返回的为空值)
```xml
<insert id="InsertOne" resultMap="Person">
　insert into Person (Name)
      values(#Name#)
　  <selectKey type="post" resultClass="int" property="Id">
　  SELECT CAST(@@IDENTITY as int) as Id
　  </selectKey>
</insert>
```
```c#
PersonModel p = new PersonModel();
p.Name = "曹操";
return (int)mapper.Insert("InsertOne",p);
```

#### Update
`public int Update(String statementName, Object parameterObject)` 
返回值为修改的行数  
```xml
<update id="UpdateOne" resultMap="Person">
      Update Person Set Name = #Name# Where Id = #Id#
</update>
```
```c#
PersonModel p = new PersonModel();
p.Id = 5;
p.Name = "张三";
return (int)mapper.Update("UpdateOne", p);
```

#### Delete
`public int Delete(String statementName, Object parameterObject)`  
返回值为删除的行数  
```xml
<delete id="DeleteOne" resultMap="Person">
    Delete Person Where Id = #Id#
</delete>
```
```c#
PersonModel p = new PersonModel();
p.Id = 5;
p.Name = "张三";
return (int)mapper.Delete("DeleteOne", p);
//return (int)mapper.Delete("DeleteOne", 5);
```