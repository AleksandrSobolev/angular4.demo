import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'longText'
})
export class LongTextPipe implements PipeTransform {
    transform(value: string, limit?: number) {
        if (!value)
            return null;

        let actualLimit = (limit) ? limit : 50;
        if(value.length > limit){
            return value.substr(0, actualLimit) + '...'; 
        }
        else{
            return value;
        }
        
    }
}