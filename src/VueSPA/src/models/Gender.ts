enum Gender {
	NoneSpecified,
	Male,
	Female,
	StrikeHelicopter
}

function genderGetDisplayName(gender: Gender): string {
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

export { genderGetDisplayName };
export default Gender;
