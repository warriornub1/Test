const numbers = [1, 2, 3, 4, 5, 6, 7, 8]

const evenNumbers = numbers.filter((number) => number % 2 === 0)
console.log(evenNumbers);

const companies = [
    { name: 'Company One', category: 'Finance', start: 1981, end: 2004 },
    { name: 'Company Two', category: 'Retail', start: 1992, end: 2008 },
    { name: 'Company Three', category: 'Auto', start: 1999, end: 2007 },
]

const retailCompanies = companies.filter(
    (company) => company.category === 'Retail'
)

console.log(retailCompanies);
