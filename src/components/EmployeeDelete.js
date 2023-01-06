import axios from "axios";
import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import swal from "sweetalert";

function EmployeeDelete() {
  const { id } = useParams();
  const [EmployeeName, setEmployeeName] = useState("");
  const [Band, setBand] = useState("");
  const [Role, setRole] = useState("");
  const [Designation, setDesignation] = useState("");
  const [Responsibilities, setResponsibilities] = useState("");
  const [EmployeeID, setEmployeeID] = useState([]);
  const navigate = useNavigate();
  
  useEffect(() => {
    axios
      .get("https://localhost:44319/api/Employees/" + id)
      .then((response) => {
        console.log(response);
        setEmployeeID(response.data.employeeId);
        setEmployeeName(response.data.employeeName);
        setBand(response.data.band);
        setRole(response.data.role);
        setDesignation(response.data.designation);
        setResponsibilities(response.data.responsibilities);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  const handelDelete = (e) => {
    e.preventDefault();
    swal({
      title: "Are you sure?",
      text: "Once deleted, you will not be able to recover",
      icon: "warning",
      buttons: true,
      dangerMode: true,
    })
    .then((willDelete) => {
      if (willDelete) {
        axios
      .delete("https://localhost:44319/api/Employees/" + id)
      .then((result) => {
        console.log(result);
        navigate("/");
      })
      .catch((error) => console.log(error));
      } else {
        swal("Not Deleted");
      }
    });
  };

  return (
    <div className="testbox">
      <form>
        <div className="item">
          <label htmlFor="employeeName" className="form-label">
            Name
          </label>
          <input
            disabled
            type="text"
            className="form-control"
            name="employeeName"
            value={EmployeeName}
          />
        </div>
        <div className="item">
          <label htmlFor="band" className="form-label">
            Band
          </label>
          <input
            disabled
            type="text"
            className="form-control"
            name="band"
            value={Band}
          />
        </div>
        <div className="item">
          <label htmlFor="role" className="form-label">
            Role
          </label>
          <input
            type="text"
            className="form-control"
            name="role"
            value={Role}
            disabled
          />
        </div>
        <div className="item">
          <label htmlFor="designation" className="form-label">
            Designation
          </label>
          <input
            disabled
            type="text"
            className="form-control"
            name="designation"
            value={Designation}
          />
        </div>
        <div className="item">
          <label htmlFor="responsibilities" className="form-label">
            Responsibilities
          </label>
          <input
            disabled
            type="text"
            className="form-control"
            name="responsibilities"
            value={Responsibilities}
          />
        </div>
        <div className="btn-block">
          <button
            type="submit"
            onClick={handelDelete}
            className="button1 btn btn-dark"
          >
            {" "}
            Delete{" "}
          </button>
          <button
            className="button1 btn btn-dark"
            type="submit"
            onClick={() => {
              navigate("/");
            }}
          >
            {" "}
            Cancel{" "}
          </button>
        </div>
      </form>
    </div>
  );
}
export default EmployeeDelete;
