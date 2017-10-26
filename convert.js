var marked = require('marked');
var fs = require('fs');

var content = fs.readFileSync('./CS_460_Software_Engineering/HW1/content.md', 'utf-8');
var convertContent = marked(content);

fs.writeFileSync('./CS_460_Software_Engineering/HW1/content.html', convertContent);