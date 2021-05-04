import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


export class Twitt {
  content: string;
  author: string;
}

@Component({
  selector: 'app-wall',
  templateUrl: './wall.component.html',
  styleUrls: ['./wall.component.css']
})
export class WallComponent implements OnInit {

  backendResponse: string;
  userName: string;
  twitt: string;
  twitts: Array<Twitt>

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get("https://localhost:44369/" + "account" + "/getUser").subscribe(response => {
      this.userName = (response as any).userName;
    },
      error => {
      });

  }

  refreshMessages() {
    this.http.get<Array<Twitt>>("https://localhost:44369/" + "twitts" + "/getTwitts").subscribe(response => {
      this.twitts = response;
    },
      error => {
        this.backendResponse = error;
      });

  }

  sendTwittRequest() {

    var twitt = new Twitt();
    twitt.content = this.twitt;
    twitt.author = this.userName;

    this.http.post<Twitt>("https://localhost:44369/" + "twitts" + "/sendTwitt", twitt).subscribe(response => {
      this.backendResponse = response.content;
    },
      error => {
        this.backendResponse = error;
      });
  }

}
