using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace ConsoleTestHackingAround
{
    public class Textler
    {
        //http://www.c-sharpcorner.com/uploadfile/scottlysle/textmsgtocellphone12112006002339am/textmsgtocellphone.aspx
        //// set up the carriers list - this is a fair list, you may wish to
        //// research the topic and add others, it took a while to generate this
        //// list...
        //cboCarrier.Items.Add("@itelemigcelular.com.br");
        //     cboCarrier.Items.Add("@message.alltel.com");
        //     cboCarrier.Items.Add("@message.pioneerenidcellular.com");
        //     cboCarrier.Items.Add("@messaging.cellone-sf.com");
        //     cboCarrier.Items.Add("@messaging.centurytel.net");
        //     cboCarrier.Items.Add("@messaging.sprintpcs.com");
        //     cboCarrier.Items.Add("@mobile.att.net");
        //     cboCarrier.Items.Add("@mobile.cell1se.com");
        //     cboCarrier.Items.Add("@mobile.celloneusa.com");
        //     cboCarrier.Items.Add("@mobile.dobson.net");
        //     cboCarrier.Items.Add("@mobile.mycingular.com");
        //     cboCarrier.Items.Add("@mobile.mycingular.net");
        //     cboCarrier.Items.Add("@mobile.surewest.com");
        //     cboCarrier.Items.Add("@msg.acsalaska.com");
        //     cboCarrier.Items.Add("@msg.clearnet.com");
        //     cboCarrier.Items.Add("@msg.mactel.com");
        //     cboCarrier.Items.Add("@msg.myvzw.com");
        //     cboCarrier.Items.Add("@msg.telus.com");
        //     cboCarrier.Items.Add("@mycellular.com");
        //     cboCarrier.Items.Add("@mycingular.com");
        //     cboCarrier.Items.Add("@mycingular.net");
        //     cboCarrier.Items.Add("@mycingular.textmsg.com");
        //     cboCarrier.Items.Add("@o2.net.br");
        //     cboCarrier.Items.Add("@ondefor.com");
        //     cboCarrier.Items.Add("@pcs.rogers.com");
        //     cboCarrier.Items.Add("@personal-net.com.ar");
        //     cboCarrier.Items.Add("@personal.net.py");
        //     cboCarrier.Items.Add("@portafree.com");
        //     cboCarrier.Items.Add("@qwest.com");
        //     cboCarrier.Items.Add("@qwestmp.com");
        //     cboCarrier.Items.Add("@sbcemail.com");
        //     cboCarrier.Items.Add("@sms.bluecell.com");
        //     cboCarrier.Items.Add("@sms.cwjamaica.com");
        //     cboCarrier.Items.Add("@sms.edgewireless.com");
        //     cboCarrier.Items.Add("@sms.hickorytech.com");
        //     cboCarrier.Items.Add("@sms.net.nz");
        //     cboCarrier.Items.Add("@sms.pscel.com");
        //     cboCarrier.Items.Add("@smsc.vzpacifica.net");
        //     cboCarrier.Items.Add("@speedmemo.com");
        //     cboCarrier.Items.Add("@suncom1.com");
        //     cboCarrier.Items.Add("@sungram.com");
        //     cboCarrier.Items.Add("@telesurf.com.py");
        //     cboCarrier.Items.Add("@teletexto.rcp.net.pe");
        //     cboCarrier.Items.Add("@text.houstoncellular.net");
        //     cboCarrier.Items.Add("@text.telus.com");
        //     cboCarrier.Items.Add("@timnet.com");
        //     cboCarrier.Items.Add("@timnet.com.br");
        //     cboCarrier.Items.Add("@tms.suncom.com");
        //     cboCarrier.Items.Add("@tmomail.net");
        //     cboCarrier.Items.Add("@tsttmobile.co.tt");
        //     cboCarrier.Items.Add("@txt.bellmobility.ca");
        //     cboCarrier.Items.Add("@typetalk.ruralcellular.com");
        //     cboCarrier.Items.Add("@unistar.unifon.com.ar");
        //     cboCarrier.Items.Add("@uscc.textmsg.com");
        //     cboCarrier.Items.Add("@voicestream.net");
        //     cboCarrier.Items.Add("@vtext.com");
        //     cboCarrier.Items.Add("@wireless.bellsouth.com"); 
        public void SendSMSTextBasic()
        {
            Console.WriteLine("I'm going to send a text now....");
            // Collect user input from the form and stow content into
            // the objects member variables
            string mTo = "6092735136@vtext.com";
            string mFrom = "steve.croce@ceinetwork.com";
            string mSubject = "dumb5";
            string mMailServer = "198.162.3.12";
            string mMsg = "dingaling5";

            // Within a try catch, format and send the message to
            // the recipient.  Catch and handle any errors.
            try
            {
                MailMessage message = new MailMessage(mFrom, mTo, mSubject, mMsg);
                SmtpClient mySmtpClient = new SmtpClient(mMailServer);
                mySmtpClient.UseDefaultCredentials = true;
                mySmtpClient.Send(message);
                Console.WriteLine("The mail message has been sent to {0}",mTo);
            }
            catch (FormatException fex)
            {
                Console.WriteLine(fex.StackTrace, fex.Message);
            }
            catch (SmtpException sex)
            {
                Console.WriteLine(sex.StackTrace, sex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace, ex.Message);
            }
        }
        public void SendSMSViaTwilio()
        {
            //https://www.twilio.com/user/account/messaging/getting-started
            //Twilio Number (609) 337-3359
            //AccountSid = "ACd0f0ed61154fb4422652200d1263f2b6";
            //string AuthToken = "a8b808126f393a7557edde721c35b708";
            //urls:
            //Voice URL: https://demo.twilio.com/welcome/voice/
            //Messaging URL:https://demo.twilio.com/welcome/sms/reply/
            //Base URL:A ll URLs referenced in the documentation have the following base:   https://api.twilio.com/2010-04-01


            //https://www.twilio.com/user/account/messaging/dev-tools/api-explorer/message-create
            //=========================================================================================
            // Download the twilio-csharp library from twilio.com/docs/csharp/install 
            //using System;
            //using Twilio;
            //Example:


            // Find your Account Sid and Auth Token at twilio.com/user/account 
            string AccountSid = "ACd0f0ed61154fb4422652200d1263f2b6";
            string AuthToken = "a8b808126f393a7557edde721c35b708";
            var twilio = new Twilio.TwilioRestClient(AccountSid, AuthToken);

            //this works
            //var message = twilio.SendMessage("6093373359", "6092735136", "this is a message from cei", "");

            //this should send an image of a hamster eating a four-leaf clover:
            var message = twilio.SendMessage("6093373359", "6092735136xx", "this is a message from cei", new string[] {"http://farm2.static.flickr.com/1075/1404618563_3ed9a44a3a.jpg" },"");

            if (message.Sid == null)
            {
                Console.WriteLine("GAAK! - something was wrong with the message, because the message Sid was {0}",message.Sid);
                throw new Exception("TWILIO BOMB");
            }
            else
            {

                Console.WriteLine("All Good! - the message SID was: " + message.Sid);
            }


            //{
            //              "sid": "SM280076cde11041a599bbcfa4b995d6e5",
            //"date_created": "Thu, 21 Apr 2016 17:18:46 +0000",
            //"date_updated": "Thu, 21 Apr 2016 17:18:46 +0000",
            //"date_sent": null,
            //"account_sid": "ACd0f0ed61154fb4422652200d1263f2b6",
            //"to": "+16092735136",
            //"from": "+16093373359",
            //"messaging_service_sid": null,
            //"body": "Sent from your Twilio trial account - this is a message from cei",
            //"status": "queued",
            //"num_segments": "1",
            //"num_media": "0",
            //"direction": "outbound-api",
            //"api_version": "2010-04-01",
            //"price": null,
            //"price_unit": "USD",
            //"error_code": null,
            //"error_message": null,
            //"uri": "/2010-04-01/Accounts/ACd0f0ed61154fb4422652200d1263f2b6/Messages/SM280076cde11041a599bbcfa4b995d6e5.json",
            //"subresource_uris": {
            //                  "media": "/2010-04-01/Accounts/ACd0f0ed61154fb4422652200d1263f2b6/Messages/SM280076cde11041a599bbcfa4b995d6e5/Media.json"
            //}
            //          }
        }

    }
}
