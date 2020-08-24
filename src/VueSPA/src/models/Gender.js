"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.genderGetDisplayName = void 0;
var Gender;
(function (Gender) {
    Gender[Gender["NoneSpecified"] = 0] = "NoneSpecified";
    Gender[Gender["Male"] = 1] = "Male";
    Gender[Gender["Female"] = 2] = "Female";
    Gender[Gender["StrikeHelicopter"] = 3] = "StrikeHelicopter";
})(Gender || (Gender = {}));
function genderGetDisplayName(gender) {
    switch (gender) {
        case Gender.NoneSpecified:
            return "None specified";
        case Gender.Male:
            return "Male";
        case Gender.Female:
            return "Female";
        case Gender.StrikeHelicopter:
            return "Stricke Helicopter";
    }
}
exports.genderGetDisplayName = genderGetDisplayName;
exports.default = Gender;
//# sourceMappingURL=Gender.js.map