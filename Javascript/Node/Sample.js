const express = require('express');
const app = express();

// Implement the GET method
app.get('/', (req, res) => {
  res.send('Hello World!');
});

// Implement the POST method
app.post('/', (req, res) => {
  res.send('Received a POST request');
});

// Implement the PUT method
app.put('/', (req, res) => {
  res.send('Received a PUT request');
});

// Implement the PATCH method
app.patch('/', (req, res) => {
  res.send('Received a PATCH request');
});

// Implement the DELETE method
app.delete('/', (req, res) => {
  res.send('Received a DELETE request');
});

app.listen(3000, () => {
  console.log('Server is listening on port 3000');
});