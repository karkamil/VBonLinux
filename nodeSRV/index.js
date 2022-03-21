const cors = require('cors');
const express = require('express');
const app = express();

app.listen('5000', () => console.log('Server is running!'));
app.use(cors());
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

app.get('/', (req, res) => {
  console.log('GET: "/" RECIVED')
  res.send('Test SRV For VB')
});

app.get('/get', (req, res) => {
  console.log('GET: "/get" RECIVED')
  res.send('From NodeJS')
});