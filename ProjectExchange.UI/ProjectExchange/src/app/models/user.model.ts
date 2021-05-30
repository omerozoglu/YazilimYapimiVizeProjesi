import { AccountType } from "./Enums/account-type";
export class User {
  id: string;
  name: string;
  username: string;
  email: string;
  password: string;
  accountType: AccountType[];
  tCNumber: string;
  phone: string;
  address: string;
  credit: number;
  products: string[];
}
