import React from 'react';
import 'antd/dist/antd.css';
import '../styles/App.css';
import { Layout, Button, Icon, Select, Input, InputNumber, Checkbox} from 'antd';
import AdminViewEntity from '../entity/AdminViewEntity';
import { statusList } from '../types/dropdownValues/statusTypes';
import { painPointList } from '../types/dropdownValues/painPointTypes';
import { industryList } from '../types/dropdownValues/industryTypes';
import { SelectOption } from '../types/dropdownValues/SelectOption';
import '../styles/AdminView.css';

const { Content} = Layout;

interface IAdminViewProps {
    data: AdminViewEntity;
}

interface IAdminViewState {
    issues: any[]
}

export default class AdminView extends React.Component<IAdminViewProps, IAdminViewState>{
    static defaultProps = {
    };

    state = {
        issues: this.props.data.issues
    }
    
    renderDropdowns = (list: SelectOption[]) => {
        return list.map((value:any) => (
            <Select.Option key={value.id} value={value.id}>{value.name}</Select.Option>))
    };

    handleChange = (e:any) => {
        console.log(e, e.target, e.target.value);
        this.setState(
            { issues: e.target.value}
        )
    }

    render() {
        return (
            <Layout>
                <Content>
                    <h2>Admin Console</h2>
                    <table className="adminTable">
                        <thead className="tableHeader"><tr>
                            <td></td>
                            <td className="thickColumn">Issue Title</td>
                            <td className="thickColumn">Description</td>
                            <td className="thickColumn">Annotation</td>
                            <td className="thickColumn">Issue Type</td>
                            <td className="thinColumn">Severity</td>
                            <td className="medColumn">Company Name</td>
                            <td className="medColumn">Industry Type</td>
                            <td className="medColumn">Date Posted</td>
                            <td className="medColumn">Submission Status</td>
                            <td className="thinColumn">Save Changes</td>
                        </tr></thead>
                        <tbody>
                            {this.state.issues.map(i => (<tr key={i.painPointId}>
                                <td><Checkbox/></td>
                                <td className="thickColumn"><a href={"/home/" + i.painPointId}>{i.painPointTitle}</a></td>
                                <td className="thickColumn"><Input key={"summary"} value={i.painPointSummary} onChange={this.handleChange} /></td>
                                <td className="thickColumn"><Input key={"annotation"} value={i.painPointAnnotation}/></td>
                                <td className="thickColumn"><Select key={"type"} defaultValue={i.painPointType}>{this.renderDropdowns(painPointList)}</Select></td>
                                <td className="thinColumn"><InputNumber key={"severity"} value={i.painPointSeverity}/></td>
                                <td className="medColumn"><Input key={"company"} value={i.companyName}/></td>
                                <td className="medColumn"><Select key={"industry"} defaultValue={i.industryType}>{this.renderDropdowns(industryList)}</Select></td>
                                <td className="medColumn">{i.datetime}</td>
                                <td className="medColumn"><Select key={"status"} defaultValue={i.submissionStatus}>{this.renderDropdowns(statusList)}</Select></td>
                                <td className="thinColumn"><Button onClick={()=>alert("Clicked!")}><Icon type="save"></Icon></Button></td>
                            </tr>))}
                        </tbody>
                    </table>
                    <Button>Create Group</Button>
                    <Button>Delete</Button>
                </Content>
            </Layout>
        )
    }
};
