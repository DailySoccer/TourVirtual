//
//  _MDPInvitationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPInvitationModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPInvitationModelAttributes {
	__unsafe_unretained NSString *answer;
	__unsafe_unretained NSString *groupName;
	__unsafe_unretained NSString *idInvitation;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *pending;
	__unsafe_unretained NSString *requestDate;
	__unsafe_unretained NSString *requestType;
} MDPInvitationModelAttributes;

extern const struct MDPInvitationModelRelationships {
	__unsafe_unretained NSString *hostUser;
} MDPInvitationModelRelationships;

@class MDPIndexedFanModel;

@interface _MDPInvitationModel : NSManagedObject

@property (nonatomic, strong) NSNumber* answer;

@property (atomic) BOOL answerValue;
- (BOOL)answerValue;
- (void)setAnswerValue:(BOOL)value_;

//- (BOOL)validateAnswer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* groupName;

//- (BOOL)validateGroupName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idInvitation;

//- (BOOL)validateIdInvitation:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* pending;

@property (atomic) BOOL pendingValue;
- (BOOL)pendingValue;
- (void)setPendingValue:(BOOL)value_;

//- (BOOL)validatePending:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* requestDate;

//- (BOOL)validateRequestDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* requestType;

@property (atomic) uint16_t requestTypeValue;
- (uint16_t)requestTypeValue;
- (void)setRequestTypeValue:(uint16_t)value_;

//- (BOOL)validateRequestType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPIndexedFanModel *hostUser;

//- (BOOL)validateHostUser:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPInvitationModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveAnswer;
- (void)setPrimitiveAnswer:(NSNumber*)value;

- (BOOL)primitiveAnswerValue;
- (void)setPrimitiveAnswerValue:(BOOL)value_;

- (NSString*)primitiveGroupName;
- (void)setPrimitiveGroupName:(NSString*)value;

- (NSString*)primitiveIdInvitation;
- (void)setPrimitiveIdInvitation:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitivePending;
- (void)setPrimitivePending:(NSNumber*)value;

- (BOOL)primitivePendingValue;
- (void)setPrimitivePendingValue:(BOOL)value_;

- (NSDate*)primitiveRequestDate;
- (void)setPrimitiveRequestDate:(NSDate*)value;

- (NSNumber*)primitiveRequestType;
- (void)setPrimitiveRequestType:(NSNumber*)value;

- (uint16_t)primitiveRequestTypeValue;
- (void)setPrimitiveRequestTypeValue:(uint16_t)value_;

- (MDPIndexedFanModel*)primitiveHostUser;
- (void)setPrimitiveHostUser:(MDPIndexedFanModel*)value;

@end
