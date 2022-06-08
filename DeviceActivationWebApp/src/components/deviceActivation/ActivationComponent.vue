<template>
    <div id="mfa-container">
        <img src="../../assets/logo-login-technoberg.png" alt="login-logo" width="150">
        <br>

        <!--        <h5 class="mt-2">Mobile Device Operating System:</h5>

                <div class="form-check">
                    <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                    <label class="form-check-label" for="flexRadioDefault1">
                        Android
                    </label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" checked>
                    <label class="form-check-label" for="flexRadioDefault2">
                        iOS
                    </label>
                </div>-->

        <br />

        <h5>Activation Code:</h5>


        <form class="row g-3">
            <div class="col-auto">
                <input class="form-control" type="text" :value="activationCode" aria-label="readonly input example" readonly>
            </div>
            <div class="col-auto">
                <button type="submit" class="btn btn-primary mb-3">Resend Activation Code</button>
            </div>
        </form>

        <button class="btn btn-primary" @click="getActivationCode">Next</button>

    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                activationCode: 0
            };
        },
        components: {},
        methods: {
            getActivationCode() {
                fetch('api/deviceactivation?username=abdul')
                    .then(async response => {


                        const data = await response.json();
                        console.log(response);
                        // check for error response
                        if (!response.ok) {
                            // get error message from body or default to response statusText
                            const error = (data && data.message) || response.statusText;
                            return Promise.reject(error);
                        }

                        this.activationCode = data;
                    })
                    .catch(err => {
                        console.log(err);

                        // this.isLoading = false;
                    })
            }
        }
    });

</script>

<style scoped>
    .submit-button {
        width: 200px;
    }

    .mfa-method-list-item-content {
        display: flex;
        flex: 1;
        gap: 5px;
        align-items: center;
    }

    .mfa-method-list {
        display: flex;
        flex-direction: column;
        gap: 3px;
    }

    .mfa-method-list-item {
        display: flex;
        /* justify-content: space-between; */
        padding: 4px;
        border: 1px solid black;
        flex: 1 1 0px;
        /* gap: 20%; */
        /* border-radius: 6px; */
    }

    #mfa-container {
        border-radius: 10px;
        max-width: 600px;
        margin: auto;
        background-color: white;
        padding: 10px;
    }

    .mfa-form-container {
        padding: 10px;
    }
</style>