export class User
    {
firstName:string;
lastName:string;
userName:string;
password:string;
img:string

constructor( firstName?: string, lastName?: string, userName?: string, password?: string,img?:string) {
   
      
    if (firstName != undefined)
      this.firstName = firstName;
    else
      this.firstName = "";
    if (lastName != undefined)
      this.lastName = lastName;
    else
      this.lastName = "";
    if (userName!= undefined)
      this.userName = userName;
    else
      this.userName = "";
    if (password != undefined)
      this.password = password;
    else 
      this.password =""
      if (img != undefined)
      this.img = img;
    else 
      this.img =""
  }
    }