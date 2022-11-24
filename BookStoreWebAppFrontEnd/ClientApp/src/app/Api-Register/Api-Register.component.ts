import { Component, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
import { Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';
@Component({
  selector: 'app-Api-Register',
  templateUrl: './Api-Register.component.html',
  styleUrls: ['./Api-Register.component.css']
})
export class ApiRegisterComponent {

  apiRegisterForm = this.formBuilder.group({
    emailAddress: '',
    password: '',
   
  });

  public HttpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(
    private http: HttpClient,
    private router: Router,
    private formBuilder: FormBuilder,
    @Inject('BASE_URL') baseUrl: string
  ) { }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
  onSubmit(): void {
    // Process checkout data here
    const url = "http://localhost:5273/" + "api/user/RegisterApiUser";

    console.log(this.apiRegisterForm.value);
    console.log(JSON.stringify(this.apiRegisterForm.value));
    //this.http.post<any>(url, JSON.stringify(this.loginForm.value), this.HttpOptions).pipe(
    //  catchError(this.handleError)
    //);

    this.http.post(url, JSON.stringify(this.apiRegisterForm.value), this.HttpOptions).subscribe(
      (response) => {
        const token = (<any>response).token;
        localStorage.setItem("jwt", token);
       
        window.alert("bearer Token: " + token);
        
      },
      (error) => console.log(error)
    )

    this.apiRegisterForm.reset();
  }
}
interface ApiRegistrationModel {
  EmailAddress: string;
  Password: string;
}
