export class ResponseType {
  private constructor(value: string) { this.Value = value; }
  Value: string;
  public static Success: ResponseType = new ResponseType("Success");
  public static Info: ResponseType = new ResponseType("Info");
  public static Warning: ResponseType = new ResponseType("Warning");
  public static Error: ResponseType = new ResponseType("Error");
}
