const math = require('mathjs');

class Neuron {
    constructor(nInputs) {
        /**
         * Initialize a neuron.
         * nInputs: Number of input features.
         */
        
        this.weights = math.multiply(math.random([nInputs]), 0.1);
        this.bias = 0.0;
        
        console.log(`Neuron initialized with ${nInputs} inputs.`);
        console.log(`Initial weights: ${this.weights}`);
        console.log(`Initial bias: ${this.bias}`);
    }

        forward(inputs) {
        /**
         * Calculate the neuron's output (weighted sum + bias).
         * inputs: An array of input features (must match nInputs).
         */

        if (inputs.length !== this.weights.length) {
            throw new Error(
                `Input size ${inputs.length} does not match neron's expected input size ${this.weights.length}.`
            )
        }

        // Calculate the weighted sum: dot product of inputs and weights
        const weightedSum = math.dot(inputs, this.weights);

        // Add bias
        const output = weightedSum + this.bias;
        return output;
    }
}

// Example: A neuron with 3 input features
if (require.main === module) {
    
    const numInputFeatures = 3;
    const neuron = new Neuron(numInputFeatures);

    // Sample input data (e.g., features of one data point)
    const sampleInputs1 = [1.0, 2.0, 3.0];
    console.log(`\nInput to neuron: ${sampleInputs1}`);

    // Calculate the neuron's output
    const output1 = neuron.forward(sampleInputs1);
    console.log(`Neuron's raw output (weighted sum + bias): ${output1.toFixed(4)}`);
}

module.exports = Neuron;