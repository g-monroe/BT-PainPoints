import React from 'react';
import { Layout, Form as AntForm, Select, Input, Button, Slider, InputNumber } from 'antd';
import * as yup from 'yup';
import { painPointList } from '../types/dropdownValues/painPointTypes';
import { industryList } from '../types/dropdownValues/industryTypes';
import { withFormik, InjectedFormikProps, Form } from 'formik';
import CreateFormEntity, { IssueEntity } from '../entity/CreateFormEntity';
import { CommentHandler } from '../utilities/commentHandler';

const { Content } = Layout;
const FormItem = AntForm.Item;

interface ICreateFormProps{
    data: CreateFormEntity; 
}

interface ICreateFormState{
    painPointType: string,
    painPointTitle: string,
    painPointSummary: string,
    painPointAnnotation?: string,
    painPointSeverity: number,

    companyName?: string,
    companyContact?: string,
    companyLocation?: string,
    industryType?: string,

    //userId?: number,
    //userName: string
}

const yupValidation = yup.object().shape<ICreateFormState>({
    painPointType: yup.string().required().label('Issue Type'),
    painPointTitle: yup.string().min(2).max(150).required().label('Issue Title'),
    painPointSummary: yup.string().min(2).max(1500).required().label('Issue Summmary'),
    painPointAnnotation: yup.string().min(1).max(1500).label('Issue Annotation'),
    painPointSeverity: yup.number().min(0).max(10).required().label('Issue Severity'),

    companyName: yup.string().label('Company Name'),
    companyContact: yup.string().label('Company Contact'),
    companyLocation: yup.string().label('Company Location'),
    industryType: yup.string().label('Industry Type')

    //userId: yup.number().required().label('User ID'),
    //userName: yup.string().required().label('User Name')
})

class CreateForm extends React.Component<InjectedFormikProps<ICreateFormProps, ICreateFormState>>{
    static defaultProps = {
    };

    state = {
        inputValue: 0
    };

    slideChange = (value: any) => {
        this.setState({
            inputValue: value
        });
    };

    getValidationStatus = (error: any) => {
        return !!error ? 'error' : 'success';
    };

    render() {
        const { values, handleSubmit, errors, handleChange, setFieldValue } = this.props;
        const css = "../src/styles/App.css";
        const { inputValue } = this.state;
        return (
            <Layout>
                <style>
                    {css}
                </style>
                <Content>
                    <Form onSubmitCapture={handleSubmit}>
                        <FormItem label="Issue Title" validateStatus={this.getValidationStatus(errors.painPointTitle)}>
                            <Input id="painPointTitle" placeholder="Title" value={values.painPointTitle} onChange={handleChange}/>
                        </FormItem>
                        <FormItem label="Issue Summary" required validateStatus={this.getValidationStatus(errors.painPointSummary)}>
                            <Input id="painPointSummary" placeholder="Description of Problem" value={values.painPointSummary} onChange={handleChange} minLength={3}/>
                        </FormItem>
                        <FormItem label="Issue Annotation" validateStatus={this.getValidationStatus(errors.painPointAnnotation)}>
                            <Input id="painPointAnnotation" placeholder="Personal Notes about Problem" value={values.painPointAnnotation} onChange={handleChange} minLength={3}/>
                        </FormItem>
                        <FormItem label="Issue Type" validateStatus={this.getValidationStatus(errors.painPointType)}>
                            <Select id="painPointType" onChange={x => setFieldValue("painPointType", x)} value={values.painPointType}>{painPointList.map(p => <Select.Option key={p.id} value={p.id}>{p.name}</Select.Option>)}</Select>
                        </FormItem>
                        <FormItem label="Issue Severity" validateStatus={this.getValidationStatus(errors.painPointSeverity)}>
                            <Slider id="painPointSeveritySlide" min={0} max={5} onChange={this.slideChange} value={typeof inputValue === 'number' ? inputValue : 0} />
                            <InputNumber id="painPointSeverityVal" min={0} max={5} value={inputValue} onChange={this.slideChange}/>
                        </FormItem>
                        <h3>If filling out an issue for a customer, please include the following:</h3>
                        <FormItem label="Company Contact" validateStatus={this.getValidationStatus(errors.companyContact)}>
                            <Input id="companyContact" placeholder="Company Contact Name" onChange={handleChange} value={values.companyContact}/>
                        </FormItem>
                        <FormItem label="Company Name" validateStatus={this.getValidationStatus(errors.companyName)}>
                            <Input id="companyName" placeholder="Company Name" onChange={handleChange} value={values.companyName}/>
                        </FormItem>
                        <FormItem label="Company Location" validateStatus={this.getValidationStatus(errors.companyLocation)}>
                            <Input id="companyLocation" placeholder="Company Location" onChange={handleChange} value={values.companyLocation}/>
                        </FormItem>
                        <FormItem label="Industry Type" validateStatus={this.getValidationStatus(errors.industryType)}>
                            <Select id="industryType" onChange={x => setFieldValue("industryType", x)} value={values.industryType}>{industryList.map(i => <Select.Option key={i.id} value={i.id}>{i.name}</Select.Option>)}</Select>
                        </FormItem>
                        <Button id="submit" htmlType="submit">Submit Problem</Button>
                    </Form>
                </Content>
            </Layout>
        )
    }
};

export default withFormik<ICreateFormProps, ICreateFormState>({
    mapPropsToValues: props => ({
        painPointId: props.data.painPointId,
        painPointType: props.data.painPointType,
        painPointTitle: props.data.painPointTitle,
        painPointSummary: props.data.painPointSummary,
        painPointAnnotation: props.data.painPointAnnotation,
        painPointSeverity: props.data.painPointSeverity,
        submissionStatus: props.data.submissionStatus,
        companyName: props.data.companyName,
        companyContact: props.data.companyContact,
        companyLocation: props.data.companyLocation,
        industryType: props.data.industryType
        //userId: props.data.userId,
        //userName: props.data.userName
    }),
    validationSchema: yupValidation,
    handleSubmit: (values, props) => {
        console.log(values);
        
        alert("You have submitted an issue");
    },
    displayName: 'Create Issue Form'
})(CreateForm);
