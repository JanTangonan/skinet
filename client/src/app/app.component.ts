import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './models/product';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  products: IProduct[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {  //take note that URL must be the same with URL from CORS policy from program.cs
    this.http.get('https://localhost:5295/api/products?pageSize=50').subscribe(
      (response: IPagination) => {
      this.products = response.data;
    }, error => {
      console.log(error);
    });
  }   
}   
