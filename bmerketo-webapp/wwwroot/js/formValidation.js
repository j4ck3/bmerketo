//credits: code from codebubb on yt with modifications.
const validateForm = formSelector => {
    const formElement = document.querySelector(formSelector);

    const validationOptions = [
        {
            attribute: 'minlength',
            isValid: input =>
                input.value && input.value.length >= parseInt(input.minLength, 10),
            errorMessage: (input, label) =>
                `${label.textContent} needs to be at least ${input.minLength} characters`,
        },
        {
            attribute: 'custommaxlength',
            isValid: input =>
                input.value.length <=
                parseInt(input.getAttribute('custommaxlength'), 10),
            errorMessage: (input, label) =>
                `${label.textContent} needs to be less than ${input.getAttribute(
                    'custommaxlength'
                )} characters`,
        },
        {
            attribute: 'pattern',
            isValid: input => {
                const patternRegex = new RegExp(input.pattern);
                return patternRegex.test(input.value);
            },
            errorMessage: (input, label) =>
                `${label.textContent} should be a valid ${label.textContent}`,
        },
        {
            attribute: 'match',
            isValid: input => {
                const matchSelector = input.getAttribute('match');
                const matchedElem = document.querySelector(`#${matchSelector}`);
                return matchedElem && matchedElem.value.trim() === input.value.trim();
            },
            errorMessage: (input, label) => {
                const matchSelector = input.getAttribute('match');
                const matchedElem = document.querySelector(`#${matchSelector}`);
                const matchedLabel =
                    matchedElem.parentElement.querySelector('label');
                return `Passwords does not match ${matchedLabel}`;
            },
        },
        {
            attribute: 'required',
            isValid: input => input.value.trim() !== '',
            errorMessage: (input, label) => `${label.textContent} is required`,
        },
    ];

    const validateSingleFormGroup = formGroup => {
        const label = formGroup.querySelector('label');
        const input = formGroup.querySelector('input, textarea, select');
        const errorContainer = formGroup.querySelector('.errormsg');
        const errorIcon = formGroup.querySelector('.icon-error');
        const successIcon = formGroup.querySelector('.icon-success');
        input.classList.add('border');
        let formGroupError = false;
        for (const option of validationOptions) {
            if (input.hasAttribute(option.attribute) && !option.isValid(input)) {
                errorContainer.textContent = option.errorMessage(input, label);
                input.classList.add('border-danger');
                input.classList.remove('border-success')
                errorIcon.classList.remove('d-none')
                successIcon.classList.add('d-none')
                formGroupError = true;
            }
        }

        if (!formGroupError) {
            errorContainer.textContent = '',
            input.classList.add('border-success');
            input.classList.remove('border-danger')
            errorIcon.classList.add('d-none')
            successIcon.classList.remove('d-none')
        }
    };


    Array.from(formElement.elements).forEach(element =>
        element.addEventListener('keyup', event => {
            validateSingleFormGroup(event.srcElement.parentElement);
        })
    );


    //formElement.addEventListener('submit', event => {
    //    event.preventDefault();
    //    validateAllFormGroups(formElement);
    //});

    //const validateAllFormGroups = formToValidate => {
    //    const formGroups = Array.from(
    //        formToValidate.querySelectorAll('.form-group')
    //    );

    //    formGroups.forEach(formGroup => {
    //        validateSingleFormGroup(formGroup);
    //    });
    //};
};

validateForm('.validate-form');