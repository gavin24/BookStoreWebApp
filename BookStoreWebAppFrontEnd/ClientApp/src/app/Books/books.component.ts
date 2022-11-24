import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-Books',
  templateUrl: './Books.component.html',
})
export class BooksComponent {
  public HttpOptions = {
    headers: new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem("jwt"),
      'Content-Type': 'text/plain'
    })
  };
  public HttpOptionsForPost = {
    headers: new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem("jwt"),
      'Content-Type': 'application/json'
    })
  };
  public books: BookModel[] = [];
  public subscribedBooks: SubscribedBookModel[] = [];
  
 // const url = "http://localhost:5273/" + "api/book/GetAllBooks";
  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log(localStorage.getItem("jwt"));
    console.log("headers: " + this.HttpOptions);
 
    http.get<BookModel[]>("http://localhost:5273/" + 'api/book/GetAllNotSubscribedBooks', this.HttpOptions).subscribe(result => {
      this.books = result;
      console.log(result);
    }, error => console.error(error));
    http.get<SubscribedBookModel[]>("http://localhost:5273/" + 'api/book/GetAllSubscribedBooksByUserId', this.HttpOptions).subscribe(result => {
      this.subscribedBooks = result;
      console.log(result);
    }, error => console.error(error));
  }
 
  

  subBook(bookModel: BookModel): void {
   
    const url = "http://localhost:5273/" + "api/book/SubscribeBook";

   
    //this.http.post<any>(url, JSON.stringify(this.loginForm.value), this.HttpOptions).pipe(
    //  catchError(this.handleError)
    //);
   
    this.http.post(url, JSON.stringify(bookModel), this.HttpOptionsForPost).subscribe(
      (response) => {
        window.location.reload();
      },
      (error: any) => console.log(error)
    )
    
  }
  unsubBook(subscribedBookModel: SubscribedBookModel): void {
    // Process checkout data here
    const url = "http://localhost:5273/" + "api/book/UnsubscribeBook";


    //this.http.post<any>(url, JSON.stringify(this.loginForm.value), this.HttpOptions).pipe(
    //  catchError(this.handleError)
    //);

    this.http.post(url, JSON.stringify(subscribedBookModel), this.HttpOptionsForPost).subscribe(
      (response) => {
        window.location.reload();
      },
      (error: any) => console.log(error)
    )
    
  }
}

interface SubscribedBookModel {
  id: number;
  name: string;
  author: string;
  description: string;
  category: string;
  purchasePrice: string;
  // Subscribed: string;
}
interface BookModel {
  id: number;
  name: string;
  author: string;
  description: string;
  category: string;
 purchasePrice: string;
 // Subscribed: string;
}
interface UserSubscriptionModel {
  BookId: string;
  IsSubscribed: string;

}
