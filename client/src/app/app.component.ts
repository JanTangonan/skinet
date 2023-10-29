import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Jumba Store';

  constructor() { }

  ngOnInit(): void {  //take note that URL must be the same with URL from CORS policy from program.cs
    
  }   
}   
