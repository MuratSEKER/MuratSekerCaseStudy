import { Component } from "@angular/core";

@Component({
    selector: "hotel-list",
    templateUrl: "hotelList.component.html",
    styleUrls:[]
})
export class HotelList {
    public hotels = [
        {
            name: "abc",
            stars:3
        }, {
            name: "abc2",
            stars: 5
        }, {
            name: "abc3",
            stars: 3
        }];
}