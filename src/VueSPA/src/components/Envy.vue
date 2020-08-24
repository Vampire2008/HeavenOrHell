<template>
	<div>
		<b-row>
			<b-col>
				<h3>Envy</h3>
			</b-col>
		</b-row>
		<b-row>
			<b-col>
				<b-form-group
					label="When your friend gets something that you want are you happy for him or angry?"
				>
					<b-radio-group v-model="form.envyToFriend">
						<b-form-radio :value="false">Happy</b-form-radio>
						<b-form-radio :value="true">Angry</b-form-radio>
					</b-radio-group>
				</b-form-group>
				<b-form-checkbox v-model="form.tryToAnnoy">Are you trying to annoy him?</b-form-checkbox>
				<b-form-group
					label="When your army won the battle are you proud of the chieftain? Or you want to be on his place?"
				>
					<b-radio-group v-model="form.proudOfTheLeader">
						<b-form-radio :value="true">Proud</b-form-radio>
						<b-form-radio :value="false">Want to be</b-form-radio>
					</b-radio-group>
				</b-form-group>
			</b-col>
		</b-row>
	</div>
</template>

<script lang="ts">
	import type EnvyModel from "@/models/EnvyModel";
	import sinForm from "@/mixins/sinForm";
	import mixins from "vue-typed-mixins";

	export default mixins(sinForm).extend({
		data(): { form: EnvyModel } {
			return {
				form: {
					envyToFriend: false,
					tryToAnnoy: false,
					proudOfTheLeader: true,
				},
			};
		},
		methods: {
			submit(): void {
				this.saveForm("Envy");
			},
		},
		created() {
			this.getValuesFromStore("envy");
		},
	});
</script>
