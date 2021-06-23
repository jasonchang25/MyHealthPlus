import { Component, OnDestroy, OnInit, ViewChild  } from '@angular/core';
import { Appointment } from '../models/appointment.model';
import { Subject } from 'rxjs';
import { AppointmentService } from '../_services/appointment.service';
import { MatTable } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { DialogBoxComponent } from '../dialog-box/dialog-box.component';

// import 'rxjs/add/operator/map';

@Component({
  selector: 'app-view-appointments',
  templateUrl: './view-appointments.component.html',
  styleUrls: ['./view-appointments.component.css']
})
export class ViewAppointmentsCompontent implements OnDestroy, OnInit {
  dtOptions: DataTables.Settings = {};
  appointments: Appointment[] = [];
  dtTrigger: Subject<any> = new Subject<any>();
  message = '';

  constructor(private appointmentService : AppointmentService, public dialog: MatDialog) { } 

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      rowCallback: (row: Node, data: any[] | Object, index: number) => {
        const self = this;
        $('td', row).off('click');
        $('td', row).on('click', () => {
          self.OpenDialog(data);
        });
        return row;
      }
    };
    
    this.appointmentService.GetAllAppointments().subscribe(
      data=>{       
        for (var i = 0; i < data.length; i++){          
          this.appointments.push({
            AppointmentId : data[i].appointmentId,
            AppointmentType : data[i].appointmentType,
            AppointmentTypeId : data[i].appointmentTypeId,
            User : { FirstName : data[i].user.firstName, LastName : data[i].user.lastName, 
                      PhoneNumber : data[i].user.phoneNumber, Email : data[i].user.email, Sex : data[i].user.sex,
                      DateOfBirth : data[i].user.dateOfBirth
                    },
            Session : {SessionId : data[i].sessionId, StartTime : data[i].session.startTime, EndTime : data[i].session.endTime},
            SessionId : data[i].sessionId,
            Comments : data[i].comments,
            AppointmentDate : new Date(data[i].appointmentDate)
          });     
        }   
        this.dtTrigger.next();     
      });
  }    

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }
  

  UpdateComment(result: any) {
    this.appointments = this.appointments.filter((value,key)=>{
      if(value.AppointmentId == result[0]){     
        value.Comments = result.Comments;
        this.appointmentService.UpdateAppointmentComments(value).subscribe();
      }
      return true;
    });
  }

  OpenDialog(obj : any) {
    const dialogRef = this.dialog.open(DialogBoxComponent, {
      width: '250px',
      data:obj
    });
    
    dialogRef.afterClosed().subscribe(result => {
      this.UpdateComment(result);
    });
  }
}