import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SubSink } from 'subsink';
import { PatientService } from '../service/patient.service';
import { ActivatedRoute } from '@angular/router';
import { GenderPatient } from '../Model/genderPatient';

@Component({
  selector: 'ngx-patients-form',
  templateUrl: './patients-form.component.html',
  styleUrls: ['./patients-form.component.scss']
})
export class PatientsFormComponent implements OnInit, OnDestroy {
  @Output() closeModal: EventEmitter<void> = new EventEmitter<void>();
  private subs = new SubSink();
  patientForm!: FormGroup;
  isEditing: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private patientService: PatientService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.subscribeToQueryParams();
  }


  onSubmit(): void {
    if (this.patientForm.valid) {
      const formData = this.patientForm.value;
      if (this.isEditing) {
        // Update existing patient
        this.patientService.updatePatient(formData).subscribe(() => {   
          this.closeModal.emit();     
        });
      } else {
        // Add new patient
        this.patientService.addPatient(formData).subscribe( {
          next:()=>{
            this.patientForm.reset();
          }
        });
      }
    }
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
  

  private initializeForm(): void {
    this.patientForm = this.formBuilder.group({
      firstName: ['', [Validators.minLength(2) , Validators.maxLength(100)]], 
      lastName: ['', [Validators.minLength(2) , Validators.maxLength(100)]],
      region: ['',[Validators.minLength(2) , Validators.maxLength(100)]], 
      gender: [GenderPatient.Unknown],
      dateOfBirth: [''],
    });
  }

  private subscribeToQueryParams(): void {
    this.subs.sink = this.route.queryParamMap.subscribe((queryParams) => {
      const patientId= Number(queryParams.get('edit'));
      if (patientId !== null) {
        this.isEditing = true;
        this.subs.sink = this.patientService.getPatientById(patientId).subscribe({
          next: (result) => {
            this.patientForm.patchValue(result);                      
          },
          error: (error) => {
            console.error('Error fetching patient:', error);
          }
        });
      }
    });
  }
}
