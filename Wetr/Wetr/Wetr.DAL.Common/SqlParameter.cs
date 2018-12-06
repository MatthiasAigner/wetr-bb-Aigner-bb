namespace Wetr.DAL.Common {

  public class SqlParameter {

    public SqlParameter(string name, object value) {
      this.Name = name;
      this.Value = value;
    }

    public string Name { get; }
    public object Value { get; } 
  }
}
