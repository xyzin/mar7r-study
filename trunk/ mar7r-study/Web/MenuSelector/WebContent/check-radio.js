/*!
 * Ext JS Library 3.3.0
 * Copyright(c) 2006-2010 Ext JS, Inc.
 * licensing@extjs.com
 * http://www.extjs.com/license
 */

    Ext.QuickTips.init();
    
    // turn on validation errors beside the field globally
    Ext.form.Field.prototype.msgTarget = 'side';
    
    // combine all that into one huge form
    var fp = new Ext.FormPanel({
        title: '선택하세요',
        frame: true,
        region:'center',
        labelWidth: 110,
        width: 600,
//        renderTo:'form-ct',
        bodyStyle: 'padding:0 10px 0;',
        items: [{
            xtype: 'radiogroup',
            fieldLabel: '식당 선택',
            itemCls: 'x-check-group-alt',
            columns: 1,
            items: [
                {boxLabel: '구내식당', name: 'rb-col', inputValue: 1},
                {boxLabel: '예쁜돼지', name: 'rb-col', inputValue: 2},
                {boxLabel: '김가네', name: 'rb-col', inputValue: 3},
                {boxLabel: '대가', name: 'rb-col', inputValue: 3},
                {boxLabel: '장어가', name: 'rb-col', inputValue: 3},
                {boxLabel: '중식당', name: 'rb-col', inputValue: 3}
            ]
        }],
        buttons: [{
            text: 'Save',
            handler: function(){
               if(fp.getForm().isValid()){
                    Ext.Msg.alert('Submitted Values', 'The following will be sent to the server: <br />'+ 
                        fp.getForm().getValues(true).replace(/&/g,', '));
                }
            }
        },{
            text: 'Reset',
            handler: function(){
                fp.getForm().reset();
            }
        }]
    });
