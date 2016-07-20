//
//  MDPPreferredPlayerItemModel.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 27/5/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>


#pragma mark - SportType
typedef NS_ENUM(NSInteger, MDPPreferredPlayerItemModelSportType) {
    MDPPreferredPlayerItemModelSportTypeFootball  = 1,
    MDPPreferredPlayerItemModelSportTypeBasket    = 2,
};


#pragma mark - Interface
@interface MDPPreferredPlayerItemModel : NSObject

- (instancetype)initWithPlayerId:(NSString *)playerId
                      playerName:(NSString *)playerName
                           order:(NSNumber *)order;

- (NSDictionary *)convertToDictionary;

@end
