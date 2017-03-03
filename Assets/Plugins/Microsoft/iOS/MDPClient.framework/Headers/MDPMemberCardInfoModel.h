//
//  MDPMemberCardInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPMemberCardInfoModel.h"


#pragma mark - MemberSeatStatusType
typedef NS_ENUM(NSInteger, MDPMemberCardInfoMemberCardType) {
    MDPMemberCardInfoMemberCardTypeMinor                = 0,
    MDPMemberCardInfoMemberCardTypeBlue                 = 1,
    MDPMemberCardInfoMemberCardTypeSilver               = 2,
    MDPMemberCardInfoMemberCardTypeGold                 = 3,
    MDPMemberCardInfoMemberCardTypeDiamond              = 4,
};


#pragma mark - Interface
@interface MDPMemberCardInfoModel : _MDPMemberCardInfoModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end














































































