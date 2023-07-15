// This JS code gets the input elements for each side of the triangle from the form,
// and continually checks the sides to ensure they are valid.

// Get form
const form = document.getElementById("triangleForm");

// put each side input into an array
const sides = form.querySelectorAll(".sides");

// iterate through each input element and set an event listener on each
sides.forEach((side) => {
    side.addEventListener("change", () => {
        // grab the current value of all sides
        const sideA = parseFloat(document.getElementById("sideA").value);
        const sideB = parseFloat(document.getElementById("sideB").value);
        const sideC = parseFloat(document.getElementById("sideC").value);

        // if any two sides are less than or equal to the third side, then display error message, and disable submit button.
        if ((sideA + sideB <= sideC) || (sideA + sideC <= sideB) || (sideC + sideB <= sideA)) {
            document.querySelector("#errorMessage").textContent = "This is an invalid Triangle";
            document.querySelector("#submitTriangle").disabled = true;
        } else {
            document.querySelector("#errorMessage").textContent = "";
            document.querySelector("#submitTriangle").disabled = false;
        }

    })
})