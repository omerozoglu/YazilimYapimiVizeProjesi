import { ResponseType } from "./Enums/response-type.enum";
export class ApiResponse {
  id: string;
  reponseName: string;
  status: ResponseType;
  message: string;
  content: any;
}
