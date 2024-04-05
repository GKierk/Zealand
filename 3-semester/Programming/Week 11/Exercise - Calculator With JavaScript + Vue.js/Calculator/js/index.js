Vue.createApp({
  data() {
    return {
      num1: 0,
      num2: 0,
      result: null,
      operation: "+"
    };
  },
  methods: {
    calculate() {
      switch (this.operation) {
        case "+":
          this.result = this.num1 + this.num2;
          break;
        case "-":
          this.result = this.num1 - this.num2;
          break;
        case "*":
          this.result = this.num1 * this.num2;
          break;
        case "/":
          this.result = this.num1 / this.num2;
          break;
        default:
          this.result = null;
      }
    }
  }
}).mount('#app')
