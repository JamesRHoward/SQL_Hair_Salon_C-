## Specs


| Behavior - plain english                                    | Input                 | Output                                |
|-------------------------------------------------------------|-----------------------|---------------------------------------|
| User creates entry for stylist                              | Jake                  | id = 1 : name = Jake                  |
| User creates entry for stylist(First stylist entry remains) | Jenny                 | id = 2 : name = Jenny                 |
| User creates entry for client for stylist Jake              | Dave                  | id = 1 : name = Dave : stylistid = 1  |
| User creates entry for client for stylist Jake(one to many) | Sally                 | id = 2 : name = Sally : stylistid = 1 |
| User updates client name entry from Dave to David           | update: Dave to David | id = 1 : name = David : stylistid = 1 |
| User updates stylist name entry from Jenny to Jen           | update: Jenny to Jen  | id = 1 : name = Jen                   |
| User deletes client David from stylist Jake                 | delete: David         | David is removed from Jake's list     |
| User deletes stylist Jake from application                  | delete: Jake          | Jake is removed from application      |
