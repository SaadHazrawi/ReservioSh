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
  patientForm: FormGroup;
  isEditing = false;
  selectGender = [];
  selectedOption;
  birthDate: Date; 

  constructor(
    private formBuilder: FormBuilder,
    private patientService: PatientService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.selectGender = Object.keys(GenderPatient)
    .filter(key => isNaN(Number(key))) // Exclude numeric keys
    .map(key => ({
      value: GenderPatient[key],
      name: key
    }));
    this.subscribeToQueryParams();
  }



  onSubmit(): void {
    if (this.patientForm.valid) {
      this.formatAndPatchDateOfBirth(this.patientForm, 'dateOfBirth');
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


  closeForm() {
    if (this.patientForm.dirty) {
      const confirmation = confirm('Are you sure you want to close? Any unsaved changes will be lost.');
      if (confirmation) {
        this.closeModal.emit();
      }
    } else {
      this.closeModal.emit();
    }
  }


  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }


  private initializeForm(): void {
    this.patientForm = this.formBuilder.group({
      patientId: [0, [Validators.required,Validators.minLength(1)]], 
      firstName: [null, [Validators.required,Validators.minLength(2) , Validators.maxLength(100)]], 
      lastName: [null, [Validators.required,Validators.minLength(2) , Validators.maxLength(100)]],
      region: [null,[Validators.required,Validators.minLength(2) , Validators.maxLength(100)]], 
      gender: [GenderPatient.Unknown ,[Validators.required]],
      dateOfBirth: [null,[Validators.required,]],
    });
  }

  private subscribeToQueryParams(): void {
    this.subs.sink = this.route.queryParamMap.subscribe((queryParams) => {
      const patientId = Number(queryParams.get('edit'));
      if (patientId > 0) {
        this.isEditing = true;
        this.subs.sink = this.patientService.getPatientById(patientId).subscribe({
          next: (result) => {
            // Patch patient data to form
            this.patientForm.patchValue(result);
          },
          error: (error) => {
            console.error('Error fetching patient:', error);
          }
        });
      }
      else {
        const isAddPatient = Boolean(queryParams.get('add'));
        if (!isAddPatient) {
          this.closeModal.emit();    
        }
      }
    });
  }
  

  formatAndPatchDateOfBirth(form: FormGroup, columnName: string): void {
    const selectedDate = new Date(form.get(columnName).value);
    const formattedDate = selectedDate.toISOString();
    form.patchValue({columnName:formattedDate});
  }
  
  
}
