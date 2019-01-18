import * as tslib_1 from "tslib";
import { Component } from "@angular/core";
var HotelList = /** @class */ (function () {
    function HotelList() {
        this.hotels = [
            {
                name: "abc",
                stars: 3
            }, {
                name: "abc2",
                stars: 5
            }, {
                name: "abc3",
                stars: 3
            }
        ];
    }
    HotelList = tslib_1.__decorate([
        Component({
            selector: "hotel-list",
            templateUrl: "hotelList.component.html",
            styleUrls: []
        })
    ], HotelList);
    return HotelList;
}());
export { HotelList };
//# sourceMappingURL=hotelList.component.js.map