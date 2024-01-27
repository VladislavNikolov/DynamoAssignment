import { Component } from '@angular/core';
import { FileUploadService } from './file-upload.serivce';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  selectedFile: File | null = null;
  uploadSuccess: string;
  uploadError: string;

  constructor(private fileUploadService: FileUploadService) {}

  handleFileInput(event: any): void {
    this.selectedFile = event.target.files[0];
    this.uploadError = null;
    this.uploadSuccess = null;
  }

  uploadFile(): void {
    if(this.selectedFile) {
      const formData = new FormData();
      formData.append('file', this.selectedFile);

      this.fileUploadService.uploadFile(formData)
        .subscribe(response => {
          this.uploadSuccess = 'File uploaded successfully!';
        }, error => {
          this.uploadError = error.error;
        });
    } else {
      this.uploadError = 'No file selected!';
    }
  }
}
