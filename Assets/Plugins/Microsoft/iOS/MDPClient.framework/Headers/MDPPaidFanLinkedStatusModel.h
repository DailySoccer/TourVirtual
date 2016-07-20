//
//  MDPPaidFanLinkedStatusModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPaidFanLinkedStatusModel.h"


#pragma mark  - PaidFanEmailConfirmationType
typedef NS_ENUM(NSInteger, MDPPaidFanLinkedStatusModelPaidFanStatusType) {
    MDPPaidFanLinkedStatusModelPaidFanStatusTypeUnsubscribed                    = 0,
    MDPPaidFanLinkedStatusModelPaidFanStatusLinked                              = 1,
    MDPPaidFanLinkedStatusModelPaidFanStatusTypeEmailUnmatch                    = 2,
};

#pragma mark  - PaidFanUnsubscribedType
typedef NS_ENUM(NSInteger, MDPPaidFanLinkedStatusModelPaidFanUnsubscribedType) {
    MDPPaidFanLinkedStatusModelPaidFanUnsubscribedDuplicated                    = 0,
    MDPPaidFanLinkedStatusModelPaidFanUnsubscribedAutomaticUnpaid               = 1,
    MDPPaidFanLinkedStatusModelPaidFanUnsubscribedTypeManualUnpaid              = 2,
    MDPPaidFanLinkedStatusModelPaidFanUnsubscribedTypeDataRemove                = 3,
    MDPPaidFanLinkedStatusModelPaidFanUnsubscribedTypePaidFanAsk                = 4,
    MDPPaidFanLinkedStatusModelPaidFanUnsubscribedTypeTeamAsk                   = 5,
};


#pragma mark - Interface
@interface MDPPaidFanLinkedStatusModel : _MDPPaidFanLinkedStatusModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
