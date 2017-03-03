//
//  MDPMemberSellMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPMemberSellMatchModel.h"


#pragma mark - MemberSeatStatusType
typedef NS_ENUM(NSInteger, MDPMemberSellMatchModelMemberSeatStatusType) {
    MDPMemberSellMatchModelMemberSeatStatusTypeCededAndUnsoldSeat       = 0,
    MDPMemberSellMatchModelMemberSeatStatusTypeSeatBelongsToMember      = 1,
    MDPMemberSellMatchModelMemberSeatStatusTypeSoldSeat                 = 2,
    MDPMemberSellMatchModelMemberSeatStatusTypeBeingSold                = 3,
};


#pragma mark - Interface
@interface MDPMemberSellMatchModel : _MDPMemberSellMatchModel

+ (instancetype)insertIfNotExistsMemberSellMatchWithDictionary:(NSDictionary *)dictionary
                                          managedObjectContext:(NSManagedObjectContext *)context;

@end
