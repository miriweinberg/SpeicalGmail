import { Component, OnInit, Input } from '@angular/core';
import { User } from './User';
import { Router } from '@angular/router';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
  styleUrls: ['./new-user.component.css']
})
export class NewUserComponent implements OnInit {
  public imagePath;
  imgURL: any;
  users:Object;
  public message: string;
  eyeClose: boolean = true;
  eyeOpen: boolean = false;
  inputType: string = "password"
  flagError=0;
  constructor(public router: Router,public usersService:UserServiceService) {
    
      this.usersService.getAllUsers().subscribe(res=>{
        this.users=res;
      })
      
    
  }
  @Input()
  user: User = new User();
  @Input()
  confirmPassword: string = "";
  preview(files) {
    // if (files.length === 0)
    //   return;
 
    // var mimeType = files[0].type;
    // if (mimeType.match(/image\/*/) == null) {
    //   this.message = "ניתן לבחור קובץ בסיומת jpg או png בלבד";
    //   return;
    // }
 if(!this.user.img.includes(".jpg")&&!this.user.img.includes(".png")&&this.user.img!=null&&this.user.img!="")
 {
  document.getElementById("spanImg").removeAttribute("hidden");
   this.flagError = 1;
   this.imgURL = "";
 }
 else{
  document.getElementById("spanImg").setAttribute("hidden", "hidden");
   var reader = new FileReader();
    this.imagePath = files;
    reader.readAsDataURL(files[0]); 
    reader.onload = (_event) => { 
      this.imgURL = reader.result;
      this.flagError=0;
 }
    
    }
  }
  validTest(files) {
    
    if (this.user.firstName == "" || this.user.firstName == null) {
      document.getElementById("spanFName").removeAttribute("hidden");
      this.flagError = 1;
    }


    else {
      var flagFN = 0;
      for (var i = 0; i < this.user.firstName.length; i++) {
        if (!(this.user.firstName[i] >= "A" && this.user.firstName[i] <= "Z" || this.user.firstName[i] >= "a" && this.user.firstName[i] <= "z"))
      { 
          flagFN = 1;
        this.flagError = 1;
      }
       
      }
      if (flagFN) {
        document.getElementById("spanFName").removeAttribute("hidden");
        document.getElementById("spanFName").innerHTML = "בטוח שהזנת את שמך נכון?";
        
      }
      else
        document.getElementById("spanFName").setAttribute("hidden", "hidden");
    }

    if (this.user.lastName == "" || this.user.lastName == null)
    {
      document.getElementById("spanLName").removeAttribute("hidden");
      this.flagError = 1;
    }
      
    else {
      var flagLN = 0;
      for (var i = 0; i < this.user.lastName.length; i++) {
        if (!(this.user.lastName[i] >= "A" && this.user.lastName[i] <= "Z" || this.user.lastName[i] >= "a" && this.user.lastName[i] <= "z"))
        {
          this.flagError = 1; 
          flagLN = 1
        }
         
      }
      if (flagLN) {
        document.getElementById("spanLName").removeAttribute("hidden");
        document.getElementById("spanLName").innerHTML = "בטוח שהזנת את שם משפחתך נכון?";
      }
      else
        document.getElementById("spanLName").setAttribute("hidden", "hidden");
    }
    if (this.user.userName == "" || this.user.userName == null) {
      // var span=document.getElementById("spanUN")
      var span = document.createElement("span");
      span.setAttribute("class", "glyphicon glyphicon-exclamation-sign")
      document.getElementById("lblUname").innerHTML = ""
      document.getElementById("lblUname").appendChild(span)
      document.getElementById("lblUname").innerHTML += "הזן כתובת specialMail"
      document.getElementById("lblUname").setAttribute("style", "color: red")
     this.flagError = 1;
    }
    else {
      if (!(this.user.userName.includes("@specialMail.com", 1))) {
        var span = document.createElement("span");
        span.setAttribute("class", "glyphicon glyphicon-exclamation-sign")
        document.getElementById("lblUname").innerHTML = ""
        document.getElementById("lblUname").appendChild(span)
        document.getElementById("lblUname").innerHTML += "שם משתמש חייב להכיל @speicalMail.com "
        document.getElementById("lblUname").setAttribute("style", "color: red")
       this.flagError = 1;
      }
      else {
        document.getElementById("lblUname").innerHTML = "מותר להשתמש באותיות, במספרים ובנקודות"
        document.getElementById("lblUname").setAttribute("style", "color: black")
      }


    }
    if (this.user.password == "" || this.user.password == null) {
      var span = document.createElement("span");
      span.setAttribute("class", "glyphicon glyphicon-exclamation-sign")
      document.getElementById("lblPass").innerHTML = ""
      document.getElementById("lblPass").appendChild(span)
      document.getElementById("lblPass").innerHTML += "הזן סיסמה"
      document.getElementById("lblPass").setAttribute("style", "color: red")
      this.flagError = 1;
    }
    else {
      if (this.user.password.length < 8) {
        var span = document.createElement("span");
        span.setAttribute("class", "glyphicon glyphicon-exclamation-sign")
        document.getElementById("lblPass").innerHTML = ""
        document.getElementById("lblPass").appendChild(span)
        document.getElementById("lblPass").innerHTML += "הזן סיסמה בת 8 תוים";
        document.getElementById("lblPass").setAttribute("style", "color: red");
        this.flagError = 1;
      }
      else {
        if (this.user.password != this.confirmPassword) {
          var span = document.createElement("span");
          span.setAttribute("class", "glyphicon glyphicon-exclamation-sign")
          document.getElementById("lblPass").innerHTML = ""
          document.getElementById("lblPass").appendChild(span)
          document.getElementById("lblPass").innerHTML += "סיסמה ואימות סיסמה אינם זהים";
          document.getElementById("lblPass").setAttribute("style", "color: red");
          this.flagError = 1;
        }
        else {
          document.getElementById("lblPass").innerHTML = "יש להשתמש ב-8 תווים או יותר בשילוב של אותיות, ספרות וסימנים";
          document.getElementById("lblPass").setAttribute("style", "color: black")
        }

      }

    }
    // if(!this.user.img.includes(".jpg")&&!this.user.img.includes(".png")&&this.user.img!=null&&this.user.img!="")
    // { 
    //   document.getElementById("spanImg").removeAttribute("hidden");
    //   flagError = 1;
    // }
   
    // else
    // document.getElementById("spanImg").setAttribute("hidden", "hidden");
    // var mimeType = files[0].type;
    // if (mimeType.match(/image\/*/) == null) {
    //   this.message = "ניתן לבחור קובץ בסיומת jpg או png בלבד";
    //   return;
    // }

    if (this.flagError == 0) {
      //מעבר לדף אחר
      this.router.navigate(['homePage'])
    }
  }
  changeUName() {
    this.user.userName += "@specialMail.com";

  }


  changeEye() {

    if (this.eyeClose == true) {
      this.inputType = "text"
      this.eyeOpen = true;
      this.eyeClose = false;
    }
    else {
      this.inputType = "password"
      this.eyeOpen = false;
      this.eyeClose = true;
    }

  }



  ngOnInit() {
  }

}
