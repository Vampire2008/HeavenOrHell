import type Gender from "./Gender";

interface PersonFormInput {
	name: string,
	dateOfBirth: Date | null,
	gender: Gender,
	color: string
}
export default PersonFormInput;
