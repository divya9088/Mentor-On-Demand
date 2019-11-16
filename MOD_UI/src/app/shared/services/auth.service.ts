import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map } from "rxjs/operators";

const httpOptions1 = {
  headers: new HttpHeaders({
    "Content-Type": "application/json"
  })
};
@Injectable({
  providedIn: "root"
})
export class AuthService {

  token:string;
  
  private loggedIn = false;

  httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json",
      "Authorizaton": this.token
    })
  };

  constructor(private http: HttpClient) {}


  // Get All - API

  public getAllRegistered() {
    console.log();
    return this.http.get("https://localhost:44359/api/admin/GetUsers");
  }

  public getAllSkills() {
    return this.http.get("https://localhost:44359/api/admin/getSkills");
  }

  public getAllTraining() {
    return this.http.get("https://localhost:44359/api/admin/getTrainings");
  }
  
  public getAllPayment() {
    return this.http.get("https://localhost:44359/api/admin/GetPayments");
  }


  // Get All By ID - API

  public getUserById(id) {
    console.log(id);
    return this.http.get("https://localhost:44359/api/admin/"+ id);
  }

  public getSkillById(id) {
    return this.http.get("https://localhost:44359/api/admin/GetSkill/" + id);
  }

  public getTrainingById(id) {
    return this.http.get("https://localhost:44359/api/admin/GetTrainingById/" + id);
  }

  public getPaymentById(id)
  {
    return this.http.get("https://localhost:44359/api/admin/GetPaymentById/" + id);
  }

  // Get Search Data - API
 
  public getSearchData(data) {
    return this.http.get(
      "https://localhost:44359/api/admin/searchdata?trainerTechnology=" + data
    );
  }

 // Post Data In Db - API

  public saveUser(regData) {
    return this.http
      .post("https://localhost:44359/api/account/register", regData, httpOptions1)
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }
 
  public saveSkill(tech) {
    console.log(tech);
    return this.http
      .post("https://localhost:44359/api/admin/skill", tech, httpOptions1)
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  public saveTraining(data) {
    return this.http
      .post("https://localhost:44359/api/admin/training", data, httpOptions1)
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  public savePayment(data) {
    console.log(data);
    return this.http
      .post("https://localhost:44359/api/admin/payment", data, httpOptions1)
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  public login(email, password) {
    let data =
    {
      email:email,
      password :password
    }
    return this.http
      .post(
        "https://localhost:44359/api/account/login",data,
        httpOptions1
      )
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  // Put Data By Id - API
  
  public updatePaymentAndCommisionById(id,model) {
    console.log("in update")
    return this.http
      .put("https://localhost:44359/api/admin/updatePaymentAndCommisionById/" + id, model, httpOptions1)
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }
  
  public updateUserProfileById(id,model)
  {
    console.log("in update")
    return this.http
    .put("https://localhost:44359/api/admin/" + id, model, httpOptions1)
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  public updateTrainerProfileById(id,model)
  {
  console.log("in update")
  return this.http
    .put("https://localhost:44359/api/admin/" + id, model, httpOptions1)
    .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
}

  public updateTrainingAndPaymentStatusById(id) {
    return this.http
      .put(
        "https://localhost:44359/api/admin/updateTrainingAndPaymentStatusbyId/" + id,
        httpOptions1
      )
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  public updateTrainingStatusById(id) {
    return this.http
      .put("https://localhost:44359/api/admin/updateTrainingStatusById/" + id, httpOptions1)
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  public updateTrainingProgress(id,progressValue) {
    return this.http
      .put("https://localhost:44359/api/admin/updateTrainingProgressById?id=" + id + "&progressValue=" + progressValue,  httpOptions1)
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  public updateTrainingRatings(id,rating) {
    return this.http
      .put("https://localhost:44359/api/admin/updateTrainingRatingById?id=" + id + "&rating=" + rating,  httpOptions1)
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  public blockById(id) {
    return this.http
      .get("https://localhost:44359/api/admin/blockunblock/" + id, httpOptions1)
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  public unBlockById(id) {
    return this.http
    .get("https://localhost:44359/api/admin/blockunblock/" + id, httpOptions1)
    .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  public acceptTrainingRequestById(id) {
    return this.http
      .put("https://localhost:44359/api/admin/acceptrequest/" + id, httpOptions1)
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  public rejectTrainingRequestById(id) {
    return this.http
      .put("https://localhost:44359/api/admin/rejectrequest/" + id, httpOptions1)
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  // Delete Data By Id - API 

  public DeleteSkillById(id) {
    return this.http
      .delete("https://localhost:44359/api/admin/DeleteSkill/" + id, httpOptions1)
      .pipe(map(data1 => (data1 = JSON.parse(JSON.stringify(data1)))));
  }

  // Store User Data For Session Purpose
  
  storeUserData(token, email, role) {
    this.token = token;
    localStorage.setItem("id_token", token);
    localStorage.setItem("role", role);
    localStorage.setItem("email",email);
  }

  isLoggedIn() {
    if (localStorage.getItem("id_token")) {
      return (this.loggedIn = true);
    }
  }
  
  logout() {
    this.token = null;
    localStorage.clear();
    this.loggedIn = false;
  }

 
}
