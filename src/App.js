import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import EmployeeList from './components/EmployeeList';
import EmployeeCreate from './components/EmployeeCreate';
import EmployeeUpdate from './components/EmployeeUpdate';
import EmployeeDelete from './components/EmployeeDelete';


function App() {
  return (
    <BrowserRouter>
    <Routes>
     <Route   path='/' element = {<EmployeeList/>}></Route>
     <Route   path='createEmployee/' element = {<EmployeeCreate/>}></Route>
     <Route   path='updateEmployee/:id' element = {<EmployeeUpdate/>}></Route>
     <Route   path='deleteEmployee/:id' element = {<EmployeeDelete/>}></Route>
    </Routes>
    </BrowserRouter>
  );
}

export default App;
