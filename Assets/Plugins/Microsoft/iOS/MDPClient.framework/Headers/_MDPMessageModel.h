//
//  _MDPMessageModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPMessageModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPMessageModelAttributes {
	__unsafe_unretained NSString *idMessage;
	__unsafe_unretained NSString *idReceiver;
	__unsafe_unretained NSString *idSender;
	__unsafe_unretained NSString *idThread;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *text;
	__unsafe_unretained NSString *timeStampSent;
} MDPMessageModelAttributes;

extern const struct MDPMessageModelRelationships {
	__unsafe_unretained NSString *pagedMessagesResults;
} MDPMessageModelRelationships;

@class MDPPagedMessagesModel;

@interface _MDPMessageModel : NSManagedObject

@property (nonatomic, strong) NSString* idMessage;

//- (BOOL)validateIdMessage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idReceiver;

//- (BOOL)validateIdReceiver:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSender;

//- (BOOL)validateIdSender:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idThread;

//- (BOOL)validateIdThread:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* text;

//- (BOOL)validateText:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* timeStampSent;

//- (BOOL)validateTimeStampSent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedMessagesModel *pagedMessagesResults;

//- (BOOL)validatePagedMessagesResults:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPMessageModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdMessage;
- (void)setPrimitiveIdMessage:(NSString*)value;

- (NSString*)primitiveIdReceiver;
- (void)setPrimitiveIdReceiver:(NSString*)value;

- (NSString*)primitiveIdSender;
- (void)setPrimitiveIdSender:(NSString*)value;

- (NSString*)primitiveIdThread;
- (void)setPrimitiveIdThread:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveText;
- (void)setPrimitiveText:(NSString*)value;

- (NSDate*)primitiveTimeStampSent;
- (void)setPrimitiveTimeStampSent:(NSDate*)value;

- (MDPPagedMessagesModel*)primitivePagedMessagesResults;
- (void)setPrimitivePagedMessagesResults:(MDPPagedMessagesModel*)value;

@end
