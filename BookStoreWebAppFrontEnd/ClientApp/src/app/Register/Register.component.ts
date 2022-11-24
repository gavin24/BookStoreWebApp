import { Component, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
import { Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';
@Component({
  selector: 'app-Register',
  templateUrl: './Register.component.html',
  styleUrls: ['./Register.component.css']
})
export class RegisterComponent {
  registerForm = this.formBuilder.group({
    emailAddress: '',
    password: '',
    firstName: '',
    lastName: ''
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
    const url = "http://localhost:5273/" + "api/user/RegisterUser";

    console.log(this.registerForm.value);
    console.log(JSON.stringify(this.registerForm.value));
    //this.http.post<any>(url, JSON.stringify(this.loginForm.value), this.HttpOptions).pipe(
    //  catchError(this.handleError)
    //);

    this.http.post(url, JSON.stringify(this.registerForm.value), this.HttpOptions).subscribe(
      (response) => {
        
        this.router.navigate(["/Login"]);
        
        console.log(response)
      },
      (error) => console.log(error)
    )

    this.registerForm.reset();
  }
}
interface RegisterModel {
  EmailAddress: string;
  Password: string;
  FirstName: string;
  LastName: string;
}
