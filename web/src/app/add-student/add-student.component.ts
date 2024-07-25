import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css'],
  encapsulation: ViewEncapsulation.Emulated
})
export class AddStudentComponent {
  studentForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
    this.studentForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      major: ['', Validators.required],
      averageGrade: ['', [Validators.required, Validators.min(0), Validators.max(100)]]
    });
  }

  onSubmit() {
    if (this.studentForm.invalid) {
      return;
    }

    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    this.http.post(this.baseUrl + 'students', this.studentForm.value, { headers }).subscribe({
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