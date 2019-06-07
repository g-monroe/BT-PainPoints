import React from 'react';
import 'antd/dist/antd.css';
import '../styles/App.css';
import { Layout, Button, Icon, Select, Input, InputNumber, Popconfirm } from 'antd';
import AdminViewEntity from '../entity/AdminViewEntity';
import { statusList } from '../types/dropdownValues/statusTypes';
import { painPointList } from '../types/dropdownValues/painPointTypes';
import { industryList } from '../types/dropdownValues/industryTypes';
import { SelectOption } from '../types/dropdownValues/SelectOption';
import '../styles/AdminView.css';
import TextArea from 'antd/lib/input/TextArea';

const { Content } = Layout;

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
    };

    renderDropdowns = (list: SelectOption[]) => {
        return list.map((value: any) => (
            <Select.Option key={value.id} value={value.id}>{value.name}</Select.Option>))
    };

    handleInput = (e: any, id: number, propName: string) => {
        const { issues } = this.state;
        const newIssues = issues.map(i => {
            if (i.painPointId === id) {
                i[propName] = e.target.value;
            }
            return i;
        });
        this.setState(
            { issues: newIssues }
        );
    };

    handleNumberInput = (e: any, id: number) => {
        const { issues } = this.state;
        const newIssues = issues.map(i => {
            if (i.painPointId === id) {
                i.painPointSeverity = e;
            }
            return i;
        });
        this.setState(
            { issues: newIssues }
        );
    };

    handleSelect = (e: any, id: number, propName: string, list: SelectOption[]) => {
        const { issues } = this.state;
        const newIssues = issues.map(i => {
            if (i.painPointId === id) {
                i[propName] = list[e - 1].name;
            }
            return i;
        });
        this.setState(
            { issues: newIssues }
        );
    };

    handleSubmit = () => {
        alert("Clicked!")
    };

    handleDelete = () => {
        alert("Deleted!")
    };

    render() {
        return (
            <Layout>
                <Content>
                    <h2>Admin Console</h2>
                    <table className="adminTable">
                        <thead className="tableHeader"><tr>
                            <td className="thinColumn">Date Posted</td>
                            <td className="megaColumn">Issue Title</td>
                            <td className="megaColumn">Description</td>
                            <td className="megaColumn">Annotation</td>
                            <td className="thinColumn">Issue Type</td>
                            <td className="thinColumn">Severity</td>
                            <td className="megaColumn">Company Name</td>
                            <td className="thinColumn">Industry Type</td>
                            <td className="thinColumn">Status</td>
                            <td className="thickColumn" colSpan={2}>Edit Issue</td>
                        </tr></thead>
                        <tbody>
                            {this.state.issues.map(i => (<tr key={i.painPointId}>
                                <td className="thinColumn">{i.datetime}</td>
                                <td className="megaColumn"><a href={"/home/" + i.painPointId}>{i.painPointTitle}</a></td>
                                <td className="megaColumn"><TextArea rows={2} key={"summary"} value={i.painPointSummary} onChange={(e) => this.handleInput(e, i.painPointId, "painPointSummary")}/></td>
                                <td className="megaColumn"><TextArea rows={2}  key={"annotation"} value={i.painPointAnnotation} onChange={(e) => this.handleInput(e, i.painPointId, "painPointAnnotation")}/></td>
                                <td className="thinColumn"><Select key={"type"} style={{ width: 100 }} dropdownMatchSelectWidth={false} defaultValue={i.painPointType}  onChange={(e) => this.handleSelect(e, i.painPointId, "painPointType", painPointList)}>{this.renderDropdowns(painPointList)}</Select></td>
                                <td className="thinColumn"><InputNumber key={"severity"} value={i.painPointSeverity} min={0} max={5} onChange={(e) => this.handleNumberInput(e, i.painPointId)}/></td>
                                <td className="megaColumn"><Input key={"company"} value={i.companyName} onChange={(e) => this.handleInput(e, i.painPointId, "companyName")}/></td>
                                <td className="thinColumn"><Select key={"industry"} style={{ width: 150 }} dropdownMatchSelectWidth={false} defaultValue={i.industryType} onChange={(e) => this.handleSelect(e, i.painPointId, "industryType", industryList)}>{this.renderDropdowns(industryList)}</Select></td>
                                <td className="thinColumn"><Select key={"status"} style={{ width: 150 }} dropdownMatchSelectWidth={false} defaultValue={i.submissionStatus}  onChange={(e) => this.handleSelect(e, i.painPointId, "submissionStatus", statusList)}>{this.renderDropdowns(statusList)}</Select></td>
                                <td className="thickColumn">
                                    <Popconfirm title="Save this Issue?" onConfirm={this.handleSubmit} okText="Yes" cancelText="No" placement="left"><Button><Icon type="save" /></Button></Popconfirm>
                                    <Popconfirm title="Delete this Issue?" onConfirm={this.handleDelete} okText="Yes" cancelText="No" placement="left"><Button><Icon type="delete" /></Button></Popconfirm>
                                </td>
                            </tr>))}
                        </tbody>
                    </table>
                </Content>
            </Layout>
        )
    }
};
