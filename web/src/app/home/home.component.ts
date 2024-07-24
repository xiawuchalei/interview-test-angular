import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

interface Student {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  major: string;
  averageGrade: number;
}
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  public students: Student[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {}

  ngOnInit() {
    this.loadStudents();
  }

  loadStudents() {
    this.http.get<Student[]>(this.baseUrl + 'students').subscribe({
      next: (result) => {
        this.students = result;
      },
      error: (error) => {
        console.error(error);
      },
    });
  }

  getGradeClass(averageGrade: number): string {
    if (averageGrade > 80) {
      return 'grade-green';
    } else if (averageGrade > 50) {
      return 'grade-orange';
    } else {
      return 'grade-red';
    }
  }

  deleteStudent(student: Student) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    this.http.delete(this.baseUrl + 'students', { headers, body: student }).subscribe({
      next: () => {
        this.loadStudents();
        console.log('Student deleted successfully');
      },
      error: (error) => {
        console.error('There was an error!', error);
      }
    });
  }
}
