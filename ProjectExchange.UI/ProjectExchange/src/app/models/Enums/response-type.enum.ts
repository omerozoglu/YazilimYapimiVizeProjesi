export class ResponseType {
  private constructor(value: string) { this.value = value; }
  value: string;
  public static Success: ResponseType = new ResponseType("Success");
  public static Info: ResponseType = new ResponseType("Info");
  public static Warning: ResponseType = new ResponseType("Warning");
  public static Error: ResponseType = new ResponseType("Error");
}
