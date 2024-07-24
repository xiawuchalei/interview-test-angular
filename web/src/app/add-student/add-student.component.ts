import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
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
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent {
  public student: Student = {
    id: 0,
    firstName: '',
    lastName: '',
    email: '',
    major: '',
    averageGrade: 0 
  };

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {}

  onSubmit() {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    this.http.post<Student>(this.baseUrl + 'students', this.student, { headers }).subscribe({
      next: (result) => {
        this.router.navigate(['/']);
        console.log('Student added successfully:', result);
      },
      error: (error) => {
        console.error('There was an error!', error);
      }
    });
  }
}