import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {
    private apiUrl: string = 'http://localhost:5230/api/uploads';

    constructor(private http: HttpClient) {}

    uploadFile(formData: FormData): Observable<any> {
        return this.http.post(this.apiUrl, formData);
    }
}