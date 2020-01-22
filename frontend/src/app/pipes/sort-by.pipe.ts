import { Pipe, PipeTransform } from '@angular/core';;

@Pipe({ name: 'sortBy' })
export class SortByPipe implements PipeTransform {

  transform(value: Choice[]): Choice[] {
     return value.sort((a,b) => a.answer.localeCompare(b.answer));
  }
}