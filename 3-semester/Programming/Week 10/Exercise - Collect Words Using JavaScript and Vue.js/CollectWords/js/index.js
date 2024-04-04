Vue.createApp({
  data() {
    return {
      word: '',
      words: [],
      message: '',
    }
  },
  computed: {
    output() {
      return this.words.join(', ');
    }
  },
  methods: {
    save() {
      this.words.push(this.word);
    },
    show() {
      if (this.words.length == 0)
      {
        this.message = 'empty'
      }
      else {
        this.message = this.output;
      }
    },
    clear() {
      this.words = []
    }
  }
}).mount('#app')