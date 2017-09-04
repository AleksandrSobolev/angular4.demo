import { Component, OnInit, Input } from '@angular/core';
import { TaskModel } from "../Model/TaskModel";
import { TaskService } from "../services/task.Service";
import { AppError } from "../common/app-error";
import { NotFoundError } from "../common/not-found-error";
import { ClientModel } from "../Model/ClientModel";

@Component({
  selector: 'task-panel',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  @Input('client') currentClient: ClientModel;
  @Input('clientTask') task: TaskModel;

  constructor(private taskService: TaskService) { }

  ngOnInit() {
  }

  onClickDelete(){
    // delete task from client side model
    let indexOfTask = this.currentClient.tasks.indexOf(this.task);
    this.currentClient.tasks.splice(indexOfTask, 1);

    // delete task on the server
    this.taskService.delete<TaskModel>(this.task.id)
    .subscribe(
      null,
      (error: AppError) => {

        if(error instanceof NotFoundError)
          alert("This task has already been deleted!");
        else {
          // if error from server (except error task already deleted) return task back to client side model
          this.currentClient.tasks.splice(indexOfTask, 0, this.task);
          throw error;
        }
      });
  }

}
